namespace WareHouse.Caches
{
    public interface ICacheManager
    {
        ICache AddOrGetExistSection(string sectionKey, ICache cache);
    }
}
