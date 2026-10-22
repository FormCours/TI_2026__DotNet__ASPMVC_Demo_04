namespace DemoCinema.WebApp.Tools
{
    public class DemoTransientTool
    {
        private static int _InternalCount = 1;


        public int InstanceId { get; set; }

        public DemoTransientTool()
        {
            InstanceId = _InternalCount;
            _InternalCount++;
        }
    }
}
