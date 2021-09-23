﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mensa.Infrastructure.STWPB
{
    public class MensaAPI
    {
        public static HttpClient HttpClient;

        private static readonly string format = "yyyy-MM-dd";

        public MensaAPI(string acceptLanguage)
        {
            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://www.studentenwerk-pb.de")
            };

            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(acceptLanguage));
        }

        public async Task<List<Meal>> GetMeals()
        {
            var meals = await HttpClient.GetFromJsonAsync<List<Meal>>($"fileadmin/shareddata/access2.php?id={Secret.id}", Converter.Options);
            return meals;
        }

        public async Task<List<Meal>> GetTodaysHammMeals()
        {
            var dateString = DateTime.Now.ToString(format);
            var meals = await HttpClient.GetFromJsonAsync<List<Meal>>($"fileadmin/shareddata/access2.php?id={Secret.id}&restaurant=mensa-hamm&date={dateString}", Converter.Options);
            return meals;
        }
    }
}
