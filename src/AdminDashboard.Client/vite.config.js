import { defineConfig } from 'vite'
import { fileURLToPath, URL } from 'node:url';
import react from '@vitejs/plugin-react'
import fs from 'fs';
import path from 'path';

const certsFolder = '../certs'
const certificateName = "server";
const certFilePath = path.join(certsFolder, `${certificateName}.pem`);
const keyFilePath = path.join(certsFolder, `${certificateName}.key`);

// const apiGateURI = import.meta.env.VITE_API_GATE1 || process.env.VITE_API_GATE1 || "https://localhost:9000";

export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
        '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  },
  server: {
    proxy: {
        '/api': {
            target: process.env.VITE_API_GATE1,
            secure: false,
            changeOrigin: false,
            rewrite: (path) => path.replace(/^\/api/, '')
        }
    },
    host: true,
    strictPort: true,
    port: 3000,
    https: {
        key: fs.readFileSync(keyFilePath),
        cert: fs.readFileSync(certFilePath),
    },
  },
})