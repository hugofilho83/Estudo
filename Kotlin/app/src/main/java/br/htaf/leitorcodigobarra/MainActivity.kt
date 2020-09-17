package br.htaf.leitorcodigobarra

import android.graphics.Color
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import com.google.android.material.snackbar.Snackbar
import com.google.zxing.BarcodeFormat
import com.google.zxing.Result
import kotlinx.android.synthetic.main.activity_main.*
import me.dm7.barcodescanner.zxing.ZXingScannerView
import me.dm7.barcodescanner.zxing.ZXingScannerView.*

class MainActivity :  ControlPermissions(),  ResultHandler {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        askCameraPermission()

        btnLimpar.setOnClickListener(){
            txtCodigoBarra.text = "";
        }
    }

    override fun onResume() {
        super.onResume()

        z_xing_scanner.setResultHandler( this )
        z_xing_scanner.startCamera()
        z_xing_scanner.setFormats( listOf(BarcodeFormat.EAN_13, BarcodeFormat.DATA_MATRIX) )
        z_xing_scanner.setMaskColor(Color.BLUE)
    }

    override fun handleResult(result: Result?) {
        Log.i("LOG", "Conteúdo do código lido: ${result!!.text}")
        Log.i("LOG", "Formato do código lido: ${result.barcodeFormat.name}")
        z_xing_scanner.resumeCameraPreview( this )

        txtCodigoBarra.text = result.text;

        //Snackbar.make(btnLimpar, result.text.toString(), Snackbar.LENGTH_LONG).show()
    }

}