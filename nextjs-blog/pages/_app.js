import '../styles/globals.css'

// For local dev ONLY
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = 0;

function MyApp({ Component, pageProps }) {
  return <Component {...pageProps} />
}

export default MyApp