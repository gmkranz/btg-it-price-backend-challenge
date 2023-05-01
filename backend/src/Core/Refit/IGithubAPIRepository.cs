

using Refit;
using System.Threading.Tasks;

namespace BTG.ITPrice.Challenge.Infrastucture.Refit

{
    public interface IGithubAPIRepository
    {
        [Get("/v1/cars")]
        Task<object> ReturnCar();

    }
}
