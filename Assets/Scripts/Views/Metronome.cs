using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Metronome : MonoBehaviour {
    public double bpm = 140.0F;
    public float gain = 0.5F;
    public int signatureHi = 4;
    public int signatureLo = 4;
    public float frequency = 0.1f;
    public float ampStart = 1.0f;
    public float ampFalloff = 0.999f;
    private double nextTick = 0.0F;
    private float amp = 0.0F;
    private float phase = 0.0F;
    private double sampleRate = 0.0F;
    private int accent;
    private bool running = false;
    void Start() {
        accent = signatureHi;
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;
        nextTick = startTick * sampleRate;
        running = true;
    }
    void OnAudioFilterRead(float[] data, int channels) {
        if (!running)
            return;
        
        double samplesPerTick = sampleRate * 60.0F / bpm * 4.0F / signatureLo;
        double sample = AudioSettings.dspTime * sampleRate;
        int dataLen = data.Length / channels;
        int n = 0;
        while (n < dataLen) {
            float x = gain * amp * Mathf.Sin(phase);
            int i = 0;
            while (i < channels) {
                data[n * channels + i] += x;
                i++;
            }
            while (sample + n >= nextTick) {
                nextTick += samplesPerTick;
                amp = ampStart;
                if (++accent > signatureHi) {
                    accent = 1;
                    amp *= 2.0F;
                }
            }
            phase += amp * frequency;
            amp *= ampFalloff;
            n++;
        }
    }
}