package br.htaf.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.graphics.Color;
import android.hardware.Camera;
import android.os.Bundle;
import android.util.Log;

import com.google.android.material.snackbar.Snackbar;
import com.google.zxing.BarcodeFormat;
import com.google.zxing.Result;

import java.util.ArrayList;
import java.util.List;

import me.dm7.barcodescanner.core.CameraUtils;
import me.dm7.barcodescanner.zxing.ZXingScannerView;

public class MainActivity extends AppCompatActivity implements ZXingScannerView.ResultHandler {

    private PermissionCameraCallback permisoes;
    private ZXingScannerView z_xing_scanner;
    public static final List<BarcodeFormat> ALL_FORMATS = new ArrayList<BarcodeFormat>();

    static {
        ALL_FORMATS.add(BarcodeFormat.UPC_A);
        ALL_FORMATS.add(BarcodeFormat.UPC_E);
        ALL_FORMATS.add(BarcodeFormat.EAN_13);
        ALL_FORMATS.add(BarcodeFormat.EAN_8);
        ALL_FORMATS.add(BarcodeFormat.RSS_14);
        ALL_FORMATS.add(BarcodeFormat.CODE_39);
        ALL_FORMATS.add(BarcodeFormat.CODE_93);
        ALL_FORMATS.add(BarcodeFormat.CODE_128);
        ALL_FORMATS.add(BarcodeFormat.ITF);
        ALL_FORMATS.add(BarcodeFormat.CODABAR);
        ALL_FORMATS.add(BarcodeFormat.QR_CODE);
        ALL_FORMATS.add(BarcodeFormat.DATA_MATRIX);
        ALL_FORMATS.add(BarcodeFormat.PDF_417);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        z_xing_scanner = new ZXingScannerView(this);
        setContentView(z_xing_scanner);



        this.permisoes = new PermissionCameraCallback(MainActivity.this);
        permisoes.askCameraPermission();
    }


    @Override
    protected void onResume() {
        super.onResume();
        z_xing_scanner.startCamera(0);

        z_xing_scanner.resumeCameraPreview(this);
        z_xing_scanner.setAutoFocus(true);
        z_xing_scanner.setFormats(ALL_FORMATS);

        z_xing_scanner.setBorderColor(Color.RED);
        z_xing_scanner.setLaserColor(Color.YELLOW);
        z_xing_scanner.setMaskColor(Color.BLUE);
    }

    @Override
    protected void onPause() {
        super.onPause();

        z_xing_scanner.stopCamera();

        Camera camera = CameraUtils.getCameraInstance();
        if( camera != null ){
            camera.release();
        }
    }

    @Override
    public void handleResult(Result result) {
        Log.i("LOG", "Conteúdo do código lido: "+ result.getText());
        Log.i("LOG", "Formato do código lido: " + result.getBarcodeFormat().name());

        z_xing_scanner.resumeCameraPreview( this );

        Snackbar.make(z_xing_scanner, "Codigo Lido: "+result.getText(),  Snackbar.LENGTH_LONG).show();

    }
}