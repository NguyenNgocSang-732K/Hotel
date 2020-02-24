using System.Collections.Generic;
using Newtonsoft.Json;
using Client.Supports;
using Client.Models.Entities;

namespace Client.Models.DTO
{
    public class ServicesDTO
    {
        private static string URL = "http://" + ConstantCuaSang.IP4() + ":1273/api/services/";

        public static List<Services> Get()
        {
            string rs = CallAPI.MethodGET(URL + "get");
            List<Services> services = JsonConvert.DeserializeObject<List<Services>>(rs);
            return services;
        }

        public static Services GetByID(int id)
        {
            string rs = CallAPI.MethodGET(URL + "get/" + id);
            Services services = JsonConvert.DeserializeObject<Services>(rs);
            return services;
        }

        public static Services Create(Services sv)
        {
            string rs = CallAPI.MethodPOST_Body(URL + "create", sv);
            Services services = JsonConvert.DeserializeObject<Services>(rs);
            return services;
        }

        public static Services Modify(Services sv)
        {
            string rs = CallAPI.MethodPUT(URL + "modify", sv);
            Services services = JsonConvert.DeserializeObject<Services>(rs);
            return services;
        }

        public static bool Remove(int id)
        {
            return CallAPI.MethodDELETE(URL + "remove/" + id);
        }
    }
}
