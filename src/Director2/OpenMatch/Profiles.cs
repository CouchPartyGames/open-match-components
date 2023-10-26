namespace Director2.OpenMatch;

public class Profiles
{
    public List<Mode> Modes { get; } = new() { new Mode("mode.ctf") };
    
    public RepeatedField<MatchProfile> GenerateProfiles()
    { 
        var profiles = new RepeatedField<MatchProfile>();
        foreach(var mode in Modes)
        {
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

    public Pool CreatePool()
    {
        return new Pool();
    }
    
    public record Mode(string Value);
}