using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace LunchTimeMCP;

[McpServerToolType]
public sealed class RestaurantTools
{
	private readonly RestaurantService restaurantService;

	public RestaurantTools(RestaurantService restaurantService)
	{
		this.restaurantService = restaurantService;
	}

	// All tools implemented here...
}