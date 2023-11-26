namespace LessonSeven.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public UserEntity()
    {
        Id = new Guid();
    }
}