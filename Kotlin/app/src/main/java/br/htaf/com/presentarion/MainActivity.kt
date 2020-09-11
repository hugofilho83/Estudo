package br.htaf.com.presentarion

import android.os.Build
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.annotation.RequiresApi
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import androidx.lifecycle.ViewModelStore
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import br.htaf.com.R
import br.htaf.com.adapters.PokemonAdapter
import br.htaf.com.data.model.Pokemon
import br.htaf.com.data.model.PokemonViewModel
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {

    private lateinit var viewModel : PokemonViewModel;

    @RequiresApi(Build.VERSION_CODES.LOLLIPOP)
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        toolBarMain.title = getString(R.string.app_name);
        setSupportActionBar(toolBarMain);

        viewModel =  ViewModelProvider(this, ViewModelProvider.NewInstanceFactory()).get(PokemonViewModel::class.java);

        viewModel.pokemonsLiveData.observe(this, Observer {
            it?.let { pokemons ->
                with(recyclePokemons)
                {
                    layoutManager = LinearLayoutManager(this@MainActivity, RecyclerView.VERTICAL, false)
                    setHasFixedSize(true)
                    adapter = PokemonAdapter(pokemons);
                }
            }
        });

        viewModel.GetPokemons();
    }




}