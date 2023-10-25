namespace Director.OM;

public class AssignTicketRequestBuilder
{
    RepeatedField<AssignmentGroup> groups = new();

    public AssignTicketRequestBuilder WithGroup(AssignmentGroup group)
    {
        groups.Add(group);
        return this;
    }

    public AssignTicketsRequest Build()
    {
        //return new AssignTicketsRequest();
        return new AssignTicketsRequest {
            Assignments = new RepeatedField<AssignmentGroup>()
        };
    }
}