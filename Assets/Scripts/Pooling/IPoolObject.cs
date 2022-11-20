public interface IPoolObject
{
    IPoolObject CreateNew();
    void SetActive(bool v);
    void Reset();
    void Destroy();
}
