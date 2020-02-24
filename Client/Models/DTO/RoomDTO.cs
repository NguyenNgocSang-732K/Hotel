using Newtonsoft.Json;
using Client.Supports;
using Client.Models.Entities;
using System.Collections.Generic;

namespace Client.Models.DTO
{
    public class RoomDTO
    {
        private static string URL = "http://" + ConstantCuaSang.IP4() + ":1273/api/room/";
        public static List<Room> Get()
        {
            string rs = CallAPI.MethodGET(URL + "get");
            List<Room> room = JsonConvert.DeserializeObject<List<Room>>(rs);
            return room;
        }

        public static Room GetByID(int id)
        {
            string rs = CallAPI.MethodGET(URL + "get/" + id);
            Room room = JsonConvert.DeserializeObject<Room>(rs);
            return room;
        }

        public static Room Create(Room r)
        {
            string rs = CallAPI.MethodPOST_Body(URL + "create", r);
            Room room = JsonConvert.DeserializeObject<Room>(rs);
            return room;
        }

        public static Room Modify(Room r)
        {
            string rs = CallAPI.MethodPUT(URL + "modify", r);
            Room room = JsonConvert.DeserializeObject<Room>(rs);
            return room;
        }

        public static bool Remove(int id)
        {
            return CallAPI.MethodDELETE(URL + "remove/" + id);
        }
    }
}
