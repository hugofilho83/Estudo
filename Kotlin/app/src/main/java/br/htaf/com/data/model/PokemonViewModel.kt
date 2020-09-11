package br.htaf.com.data.model

import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.os.AsyncTask
import android.util.Log
import android.widget.ImageView
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import br.htaf.com.data.PokeApiService
import br.htaf.com.data.response.PokemonsBodyResponse
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.io.InputStream
import java.net.URL


class PokemonViewModel : ViewModel() {

    val pokemonsLiveData: MutableLiveData<List<Pokemon>> = MutableLiveData();

    fun GetPokemons()
    {
        //pokemonsLiveData.value = getListFakePokemon();

        PokeApiService.iniRetrofit().getPokemonsResponse().enqueue(object :
            Callback<PokemonsBodyResponse> {
            override fun onResponse(
                call: Call<PokemonsBodyResponse>,
                response: Response<PokemonsBodyResponse>
            ) {
                if (response.isSuccessful) {
                    val pokemons: MutableList<Pokemon> = mutableListOf();

                    response.body()?.let { pokemonsbodyResponse ->
                        for (result in pokemonsbodyResponse.pokemonResults) {
                            val pokemon: Pokemon = Pokemon(
                                number = pokemons.count() + 1,
                                name = result.name,
                                "",
                                "",
                                0F,
                                0F
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