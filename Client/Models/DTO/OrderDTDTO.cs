using System.Collections.Generic;
using Newtonsoft.Json;
using Client.Supports;
using Client.Models.Entities;

namespace Client.Models.DTO
{
    public class OrderDTDTO
    {
        private static string URL = "http://" + ConstantCuaSang.IP4() + ":1273/api/orderdetail/";

        public static List<OrderDetail> Get(int id)
        {
            string rs = CallAPI.MethodGET(URL + "get/" + id);
            List<OrderDetail> orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(rs);
            return orderDetails;
        }

        public static int Create(List<OrderDetail> list)
        {
            string rs = CallAPI.MethodPOST_Body(URL + "create", list);
            int resutl = JsonConvert.DeserializeObject<int>(rs);
            return resutl;
        }

    }
}
