namespace app.utility.extensions
{
  public interface IProcessAnItem<in ItemToProcess>
  {
    void process(ItemToProcess item);
  }
}