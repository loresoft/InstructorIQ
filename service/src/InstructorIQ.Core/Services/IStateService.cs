namespace InstructorIQ.Core.Services
{
    public interface IStateService
    {
        void WriteState<T>(T state, string name);
        T ReadState<T>(string name);
    }
}