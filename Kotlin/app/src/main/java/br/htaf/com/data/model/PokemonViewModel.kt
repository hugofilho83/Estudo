package br.htaf.com.data.model

import android.graphics.drawable.Drawable
import androidx.core.content.res.ResourcesCompat
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import br.htaf.com.data.PokeApiService
import br.htaf.com.data.response.PokemonsBodyResponse
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import br.htaf.com.R


class PokemonViewModel : ViewModel() {

    val pokemonsLiveData: MutableLiveData<List<Pokemon>> = MutableLiveData();

    fun GetPokemons()
    {
        //pokemonsLiveData.value = getListFakePokemon();

        PokeApiService.iniRetrofit().getPokemonsResponse(0, 1050).enqueue(object :
            Callback<PokemonsBodyResponse> {
            override fun onResponse(
                call: Call<PokemonsBodyResponse>,
                response: Response<PokemonsBodyResponse>
            ) {
                if (response.isSuccessful) {
                    val pokemons: MutableList<Pokemon> = mutableListOf();

                    response.body()?.let { pokemonsbodyResponse ->

                        for (result in pokemonsbodyResponse.pokemonResults) {
                            val separado: List<String> = result.url.split("/").map { it.trim() };
                            val pokemon: Pokemon = Pokemon(
                                number = separado[6],
                                name = result.name,
                                photo =  null
                            );

                            pokemons.add(pokemon);
                        }
                    }

                    pokemonsLiveData.value = pokemons;
                }
            }

            override fun onFailure(call: Call<PokemonsBodyResponse>, t: Throwable) {
                TODO("Not yet implemented")
            }

        })
    }
}