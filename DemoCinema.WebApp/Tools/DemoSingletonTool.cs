namespace DemoCinema.WebApp.Tools
{
    public class DemoSingletonTool
    {
        private static int _InternalCount = 1;


        public int InstanceId { get; set; }

        public DemoSingletonTool()
        {
            InstanceId = _InternalCount;
            _InternalCount++;
        }
    }
}
