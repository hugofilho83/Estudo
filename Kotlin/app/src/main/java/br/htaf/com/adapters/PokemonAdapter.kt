package br.htaf.com.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import br.htaf.com.R


class PokemonAdapter: RecyclerView.Adapter<PokemonAdapter.PokemonViewHolder>() {



    override fun onCreateViewHolder(parent: ViewGroup, view: Int): PokemonViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.item_pokemon, parent, false);
        return PokemonViewHolder(view);
    }

    override fun getItemCount(): Int {
        TODO("Not yet implemented")
    }

    override fun onBindViewHolder(holder: PokemonViewHolder, position: Int) {
        TODO("Not yet implemented")
    }


    class PokemonViewHolder(view: View) : RecyclerView.ViewHolder(view){}
}