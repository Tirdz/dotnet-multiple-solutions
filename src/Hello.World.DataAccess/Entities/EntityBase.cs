namespace Hello.World.DataAccess.Entities;

public class EntityBase
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}
