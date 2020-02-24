using System.Collections.Generic;
using Newtonsoft.Json;
using Client.Supports;
using Client.Models.Entities;

namespace Client.Models.DTO
{
    public class OrderDTO
    {
        private static string URL = "http://" + ConstantCuaSang.IP4() + ":1273/api/order/";

        public static List<Order> Get()
        {
            string rs = CallAPI.MethodGET(URL + "get");
            List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(rs);
            return orders;
        }

        public static Order GetByID(int id)
        {
            string rs = CallAPI.MethodGET(URL + "get/" + id);
            Order orders = JsonConvert.DeserializeObject<Order>(rs);
            return orders;
        }

        public static Order Create(Order o)
        {
            string rs = CallAPI.MethodPOST_Body(URL + "create", o);
            Order order = JsonConvert.DeserializeObject<Order>(rs);
            return order;
        }
    }
}
