using System.Collections.Generic;

namespace PostmanCollectionGenerator.Models
{

    public class PostmanCollection
    {
        public Info info { get; set; }
        public List<Item> item { get; set; }
    }

    public class Info
    {
        public string _postman_id { get; set; }
        public string name { get; set; }
        public string schema { get; set; }
    }

    public class Item
    {
        public string name { get; set; }
        public Protocolprofilebehavior protocolProfileBehavior { get; set; }
        public Request request { get; set; }
        public object[] response { get; set; }
    }

    public class Protocolprofilebehavior
    {
        public bool disableBodyPruning { get; set; }
    }

    public class Request
    {
        public string method { get; set; }
        public object[] header { get; set; }
        public Body body { get; set; }
        public Url url { get; set; }
    }

    public class Body
    {
        public string mode { get; set; }
        public string raw { get; set; }
        public Options options { get; set; }
    }

    public class Options
    {
        public Raw raw { get; set; }
    }

    public class Raw
    {
        public string language { get; set; }
    }

    public class Url
    {
        public string raw { get; set; }
        public string[] host { get; set; }
        public string[] path { get; set; }
    }

}