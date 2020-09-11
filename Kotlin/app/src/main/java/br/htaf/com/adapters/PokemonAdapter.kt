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
            txtNumber.text = "#"+pokemon.number;

            imgPhoto.setImageResource(R.drawable.picture_120px);

            if(pokemon.photo == null){
                pokemon.photo =  DownloadImageTask(imgPhoto, pokemon.photo).execute(pokemon.number).get();
            }else{
                imgPhoto.setImageBitmap(pokemon.photo);
            }
        }
    }

    private class DownloadImageTask(bmImage: ImageView, photo :Bitmap?) : AsyncTask<String?, Void?, Bitmap?>() {
        var bmImage: ImageView = bmImage
        var photo : Bitmap? = photo

        override fun onPostExecute(result: Bitmap?) {
            bmImage.setImageBitmap(result)
            result.let {
                photo = it;
            }
        }

        override fun doInBackground(vararg params: String?): Bitmap? {
            //val urlimage = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + params[0] + ".png";
            val urlimage = "https://pokeres.bastionbot.org/images/pokemon/" + params[0] + ".png";
            var image: Bitmap? = null;
            try {
                val imgStream: InputStream = URL(urlimage).openStream();
                image = BitmapFactory.decodeStream(imgStream);
            } catch (e: Exception) {
                Log.e("Error", e.message);
                e.printStackTrace();
            }

            return image;
        }
    }
}