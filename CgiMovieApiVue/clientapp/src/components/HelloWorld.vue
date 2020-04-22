<template>

    <div>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.8.1/css/bulma.css" />

        <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Category</th>
                    <th>Year</th>
                    <th>Rating</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="movie in movies" v-bind:key="movie">
                    <td>{{ movie.title }}</td>
                    <td>{{ movie.category.name }}</td>
                    <td>{{ movie.year }}</td>
                    <td>{{ movie.rating }}</td>
                </tr>
            </tbody>
        </table>        
    </div>

    
</template>

<script>
    export default {
        name: 'HelloWorld',
        props: {
            msg: String
        },
        data() {
            return { movies: [] };
        },
        created() {
            fetch('api/movies')
                .then(res => res.json())
                .then(movies => { this.movies = movies; });
        }
    }
</script>



<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }
</style>
