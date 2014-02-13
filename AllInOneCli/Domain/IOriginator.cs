namespace AllInOneCli.Domain
{
	public interface IOriginator
	{
		IMemento CreateMemento();
		void SetMemento(IMemento memento);
	}
}
