package br.htaf.com.adapters

import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.os.AsyncTask
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.cardview.widget.CardView
import androidx.recyclerview.widget.RecyclerView
import br.htaf.com.R
import br.htaf.com.data.model.Pokemon
import kotlinx.android.synthetic.main.item_pokemon.view.*
import kotlinx.android.synthetic.main.item_pokemon.view.imgFoto
import kotlinx.android.synthetic.main.item_pokemon.view.txtName
import kotlinx.android.synthetic.main.item_pokemon.view.txtNumber
import kotlinx.android.synthetic.main.item_pokemon_carview.view.*
import java.io.InputStream
import java.net.URL


class PokemonAdapter(
    val pokemons : List<Pokemon>
): RecyclerView.Adapter<PokemonAdapter.PokemonViewHolder>() {



    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): PokemonViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.item_pokemon_carview, parent, false);
        return PokemonViewHolder(view);
    }

    override fun getItemCount() = pokemons.count();

    override fun onBindViewHolder(viewHolder: PokemonViewHolder, position: Int) {

        viewHolder.bindView(pokemons[position])

    }


    class PokemonViewHolder(view: View) : RecyclerView.ViewHolder(view)
    {
        val card :CardView = view.cardPokemon;
        private val txtName = view.txtName;
        private val txtNumber =  view.txtNumber;
        private val imgPhoto = view.imgFoto;

        fun bindView(pokemon: Pokemon) {
            txtName.text = pokemon.name;
            txtNumber.text = "#"+pokemon.number.toString();
            val downloadImageTask = DownloadImageTask(imgPhoto).execute(pokemon.number.toString());
        }
    }

    private class DownloadImageTask(bmImage: ImageView) :
        AsyncTask<String?, Void?, Bitmap?>() {
        var bmImage: ImageView

        override fun onPostExecute(result: Bitmap?) {
            bmImage.setImageBitmap(result)
        }

        init {
            this.bmImage = bmImage
        }

        override fun doInBackground(vararg params: String?): Bitmap? {
            val urldisplay = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + params[0] + ".png"
            var mIcon11: Bitmap? = null
            try {
                val `in`: InputStream = URL(urldisplay).openStream()
                mIcon11 = BitmapFactory.decodeStream(`in`)
            } catch (e: Exception) {
                Log.e("Error", e.message)
                e.printStackTrace()
            }
            return mIcon11
        }
    }
}