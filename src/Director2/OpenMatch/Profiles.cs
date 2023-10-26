namespace Director2.OpenMatch;

public class Profiles
{
    public List<Mode> Modes { get; } = new() { new Mode("mode.ctf") };
    
    public RepeatedField<MatchProfile> GenerateProfiles()
    { 
        var profiles = new RepeatedField<MatchProfile>();
        foreach(var mode in Modes)
        {

            //Pool pool = new PoolBuilder().WithName().AddTags().AddStringFilters().AddRangeFilters().Build();
            
            //mode.Value;
            Pool pool = new Pool
            {
                Name = $"pool_{mode.Value}",
                TagPresentFilters = { },
                StringEqualsFilters = { }
            };

            var profile = new MatchProfile();
            profile.Name = $"profile_{mode.Value}";
            profile.Pools.Add(pool);
            
            profiles.Add(profile);
        }

        return profiles;
    }

    public class PoolBuilder
    {
        private string _name = "default";
        
        public PoolBuilder WithName(string name)
        {
             _name = name;
             return this;
        }

        public PoolBuilder AddTags()
        {
            return this;
        }

        public PoolBuilder AddStringFilters()
        {
            return this;
        }

        public PoolBuilder AddRangeFilters()
        {
            return this;
        }

        public Pool Build()
        {
            return new Pool
            {
                Name = _name,
                DoubleRangeFilters = {  },
                StringEqualsFilters = {  },
                TagPresentFilters = {  }
            };
        }
    }
    
    public record Mode(string Value);
}