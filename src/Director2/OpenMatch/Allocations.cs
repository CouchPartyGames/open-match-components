namespace Director2.OpenMatch;


public class Allocations
{
    public bool AllocateGameServer()
    {
        return true;
    }
    
    
    public class RequestBuilder
    {
        public string _namespace = "default";
            
        public RequestBuilder WithNamespace(string ns) {
            _namespace = ns;
            return this;
        }

        public RequestBuilder WithGameSelectors(Dictionary<string, string> labels) {
            return this;
        }

        public RequestBuilder WithMetadata(Dictionary<string, string> labels, Dictionary<string, string> annotations) {
            return this;
        }

        public RequestBuilder WithMultiCluster(bool multi) {
            return this;
        }

        /*
        public AllocationRequest Build() {
            return new AllocationRequest {
                Namespace = namespace
            };
        }*/
    }
}