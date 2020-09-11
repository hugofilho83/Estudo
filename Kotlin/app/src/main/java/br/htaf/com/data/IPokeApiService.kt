package br.htaf.com.data

import br.htaf.com.data.model.Pokemon
import br.htaf.com.data.response.PokemonsBodyResponse
import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Query


interface IPokeApiService {
    @GET("pokemon")
    fun getPokemonsResponse(
        @Query("offset") offset : Int  = 0 ,
        @Query("limit") limit: Int = 151
    ): Call<PokemonsBodyResponse>

    @GET("pokemon/{id}")
    fun getPokemonDetails()
}