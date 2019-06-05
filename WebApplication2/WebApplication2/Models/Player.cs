using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Player
    {
        [NotMapped]
        private readonly string StoreSessionListKey = "session_player_add_list";
        [NotMapped]
        public bool isRecentlyAdded = false;
        [Key]
        public int Id { get; set; }
        [MinLength(2)]
        [Required]
        public string Name { get; set; }
        public ICollection<Partij> Partij { get; set; } = new List<Partij>();

        public bool hasPlayedDay(Dagen dag)
        {
            Partij result = this.getPartijFromDay(dag);
            return result != null;
        }

        public Partij getPartijFromDay(Dagen dag)
        {
            Partij result = this.Partij.FirstOrDefault(p => p.Dag == dag);
            return result;
        }

        public static ICollection<Player> GetRecentlyAddedPlayers(IHttpContextAccessor contextAccessor)
        {
            var _session = contextAccessor.HttpContext.Session;
            if(_session == null)
            {
                throw new ArgumentNullException("_session");
            }
            string sessionJson = _session.GetString("session_player_add_list");
            if(string.IsNullOrEmpty(sessionJson))
            {
                return new List<Player>();
            }
            return JsonConvert.DeserializeObject<List<Player>>(sessionJson);
        }

        public void AddRecentlyAddedPlayer(IHttpContextAccessor contextAccessor)
        {
            var _session = contextAccessor.HttpContext.Session;
            if(_session == null)
            {
                throw new NullReferenceException("_session");
            }
            string sessionJson = _session.GetString(this.StoreSessionListKey);
            var _list = new List<Player>();
            if (!string.IsNullOrEmpty(sessionJson))
            {
                _list = JsonConvert.DeserializeObject<List<Player>>(sessionJson);
            }
            this.isRecentlyAdded = true;
            _list.Add(this); // this is a player
            _session.SetString(this.StoreSessionListKey, JsonConvert.SerializeObject(_list));
        }
    }
}
