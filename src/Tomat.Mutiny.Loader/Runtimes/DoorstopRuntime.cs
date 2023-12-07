using System;
using JetBrains.Annotations;
using Tomat.Mutiny.Loader.API.Runtimes;
using Tomat.Mutiny.Loader.Runtimes;

namespace Tomat.Mutiny.Loader.Runtimes {
    internal abstract class DoorstopRuntime : IRuntime {
        public string Name => "Doorstop";

        public Version Version => new(GetMajorDoorstopVersion(), 0, 0, 0);

        protected abstract int GetMajorDoorstopVersion();
    }

    internal sealed class Doorstop3Runtime : DoorstopRuntime {
        protected override int GetMajorDoorstopVersion() {
            return 3;
        }
    }

    internal sealed class Doorstop4Runtime : DoorstopRuntime {
        protected override int GetMajorDoorstopVersion() {
            return 4;
        }
    }
}

namespace Doorstop {
    internal static class Entrypoint {
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private static void Main() {
            Shared(new Doorstop3Runtime());
        }

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private static void Start() {
            Shared(new Doorstop4Runtime());
        }

        private static void Shared(IRuntime runtime) { }
    }
}
