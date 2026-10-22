namespace DemoCinema.WebApp.Tools
{
    public class DemoScopedTool
    {
        private static int _InternalCount = 1;


        public int InstanceId { get; set; }

        public DemoScopedTool()
        {
            InstanceId = _InternalCount;
            _InternalCount++;
        }
    }
}
