using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Web.Script.Serialization;

namespace WoFlow.NodeTraversal
{
    public class API_Request
    {
        string nodeIds = "089ef556-dfff-4ff2-9733-654645be56fe";
        private string url = "https://nodes-on-nodes-challenge.herokuapp.com/nodes/";

        public async Task<List<Node>> GetNodes()
        {
            using(var client = new HttpClient())
            {
                var content = await client.GetStringAsync(url+nodeIds);
                return MapJsonToNode(content);
            }
        }
        private List<Node> MapJsonToNode(string json)
        {
            var result = new List<Node>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            result = js.Deserialize<List<Node>>(json);
            return result;
        }
    }
}
