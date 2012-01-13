namespace app.utility.extensions
{
  public interface IProcessAndItemAndReturnState<in ItemToProcess,ReturnType> : IProcessAnItem<ItemToProcess>
  {
    ReturnType get_result();
  }
}