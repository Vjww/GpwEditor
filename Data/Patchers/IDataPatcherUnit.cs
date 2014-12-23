namespace Data.Patchers.Enhancements.Units
{
    public interface IDataPatcherUnit
    {
        long UnmodifiedVirtualFilePosition { get; }
        long ModifiedVirtualFilePosition { get; }

        byte[] GetUnmodifiedInstructions();
        byte[] GetModifiedInstructions();
    }
}