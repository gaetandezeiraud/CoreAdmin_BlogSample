import Head from 'next/head'
import styles from '../styles/Home.module.css'

export const getServerSideProps = async (context) => {
    const slug = context.params.slug;

    // Request data to the backend
    const req = await fetch('https://localhost:7069/Blog/' + slug, {
        method: 'GET'
    })

    const blogPost = await req.json()
    return {
        props: {
            post: blogPost
        }
    }
}

export default function Home({ post }) {
    return (
        <div className={styles.container}>
            <Head>
                <title>{post.title} - NextJS Blog</title>
            </Head>

            <main className={styles.main}>
                <article className={styles.article}>
                    <h1 className={styles.title}>
                        {post.title}
                    </h1>

                    <p className={styles.description}>
                        At {new Date(post.created).toLocaleString()}
                    </p>

                    <div dangerouslySetInnerHTML={{ __html: post.rawHTML }}>
                    </div>
                </article>
            </main>
        </div>
    )
}