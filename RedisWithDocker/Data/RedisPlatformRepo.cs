using RedisWithDocker.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace RedisWithDocker.Data {
    public class RedisPlatformRepo : IPlatformRepo {
        private readonly IConnectionMultiplexer _redis;

        public RedisPlatformRepo(IConnectionMultiplexer redis) {
            _redis = redis;
        }

        public void CreatePlatform(Platform plat) {
            if (plat == null) {
                throw new ArgumentOutOfRangeException(nameof(plat));
            }

            var db = _redis.GetDatabase();

            var serialPlat = JsonSerializer.Serialize(plat);

            db.StringSet(plat.Id, serialPlat);
        }

        public Platform GetPlatformById(string id) {
            var db = _redis.GetDatabase();

            var plat = db.StringGet(id);

            if (!string.IsNullOrEmpty(plat)) {
                return JsonSerializer.Deserialize<Platform>(plat);
            }

            return null;
        }
    }
}
