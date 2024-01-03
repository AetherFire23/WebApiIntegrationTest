namespace WebApplication1;

public class MyOtherRepository
{
    private MyRepository _myRepository;
    private MyContext _myContext;
    public MyOtherRepository(MyRepository myRepository, MyContext myContext)
    {
        _myRepository = myRepository;
        _myContext = myContext;
    }

    public async Task AddMyEntity(MyEntity entity)
    {
        _myContext.MyEntities.Add(entity);
        await _myContext.SaveChangesAsync();
    }
}
