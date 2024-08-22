namespace DataBase.Entities;

public class UserSignInEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime SignInTime { get; set; }
}
