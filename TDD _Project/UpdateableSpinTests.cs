using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Project
{
    public class UpdateableSpinTests
    {
        [Fact]
        public void Wait_NoPulse_ReturnsFalse()
        {
            UpdateableSpin spin = new UpdateableSpin();
            bool wasPulsed = spin.Wait(TimeSpan.FromMilliseconds(10));
            Assert.False(wasPulsed);
        }

        [Fact]
        public void Wait_NoPulse_ReturnsTrue()
        {
            UpdateableSpin spin = new UpdateableSpin();

            Task.Factory.StartNew(() =>
            {
                // Simulate some work
                Thread.Sleep(100);
                spin.Set();
                // In a real scenario, you would pulse the spin here
            });
            bool wasPulsed = spin.Wait(TimeSpan.FromSeconds(10));
            Assert.True(wasPulsed);
        }
    }

    public class UpdateableSpin
    {
        private readonly object lockObj = new object();
        private bool shouldWait = true;
        public bool Wait(TimeSpan millisecondsTimeout)
        {
            Thread.Sleep(millisecondsTimeout); // Simulate waiting
            // Simulate waiting without being pulsed
            if (!shouldWait)
                return true; // Indicate that it was pulsed
            
            return false; // Indicate that it was not pulsed
        }

        public void Set()
        {
            lock (lockObj)
            {
                shouldWait = false;
                // Pulse logic would go here
            }
        }
    }
}
