using RedisWithDocker.Models;
using System;
using System.Collections.Generic;

namespace RedisWithDocker.Data {
    public interface IPlatformRepo {
        void CreatePlatform(Platform plat);
        Platform GetPlatformById(string id);    }
}
