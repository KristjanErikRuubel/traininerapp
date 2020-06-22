using ee.itcollege.krruub.Contracts.BLL.Base.Mappers;

namespace ee.itcollege.krruub.BLL.Base.Mappers
{
    public class IdentityMapper<TInObject, TOutObject> : IBaseBLLMapper<TInObject, TOutObject>
        where TInObject : class, new() 
        where TOutObject : class, new()
    {
        public TOutObject Map(TInObject inObject) 
        {
            return inObject as TOutObject ?? default!;
        }

        public TMapOutObject Map<TMapInObject, TMapOutObject>(TMapInObject inObject) 
            where TMapInObject : class, new() 
            where TMapOutObject : class, new()
        {
            return inObject as TMapOutObject ?? default!;
        }
    }
}