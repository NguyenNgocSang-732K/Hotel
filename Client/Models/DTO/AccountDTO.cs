using System.Collections.Generic;
using Newtonsoft.Json;
using Client.Supports;
using Client.Models.Entities;

namespace Client.Models.DTO
{

    public class AccountDTO
    {
        private static string URL = "http://" + ConstantCuaSang.IP4() + ":1273/api/account/";
        public static List<Account> Get()
        {
            string rs = CallAPI.MethodGET(URL + "get");
            List<Account> account = JsonConvert.DeserializeObject<List<Account>>(rs);
            return account;
        }

        public static Account GetByID(int id)
        {
            string rs = CallAPI.MethodGET(URL + "get/" + id);
            Account account = JsonConvert.DeserializeObject<Account>(rs);
            return account;
        }

        public static Account Create(Account account)
        {
            string rs = CallAPI.MethodPOST_Body(URL + "create", account);
            Account acc = JsonConvert.DeserializeObject<Account>(rs);
            return acc;
        }

        public static Account Modify(Account acc)
        {
            string rs = CallAPI.MethodPUT(URL + "modify", acc);
            Account account = JsonConvert.DeserializeObject<Account>(rs);
            return account;
        }

        public static bool Remove(int id)
        {
            return CallAPI.MethodDELETE(URL + "remove/" + id);
        }

        public static Account LoginAsync(Account account)
        {
            string rs = CallAPI.MethodPOST_Body(URL + "login", new { email = account.Email, password = account.Password });
            return rs == null ? null : JsonConvert.DeserializeObject<Account>(rs);
        }
    }
}
