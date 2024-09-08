namespace Middlewear.Services;

public interface IActiveHours
{
    bool IsActive();
}
public class ActiveHours : IActiveHours
{
    public bool IsActive() => (DateTime.Now.Hour > 8 && DateTime.Now.Hour < 16);
    
}
