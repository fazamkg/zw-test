namespace Core
{
    public interface IPoolable
    {
        public void OnCreateFromPool(IObjectPool pool);

        public void OnPopFromPool();

        public void OnReturnToPool();
    }
}
