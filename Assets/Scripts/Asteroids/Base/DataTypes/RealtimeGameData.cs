namespace MK.Asteroids
{
    public class RealtimeGameData
    {
        public int Score { get; set; }
        public float RayCooldown { get; set; }
        public int RayAmmunitionCount { get; set; }
        public bool GameIsOver { get; set; }

        private int _dafaultRayAmmunitionCount;

        public RealtimeGameData(int rayAmmunitionCount)
        {
            RayAmmunitionCount = rayAmmunitionCount;
            _dafaultRayAmmunitionCount = rayAmmunitionCount;
        }
        public void Reset()
        {
            GameIsOver = false;
            Score = 0;
            RayCooldown = 0;
            RayAmmunitionCount = _dafaultRayAmmunitionCount;
        }
        
    }
}