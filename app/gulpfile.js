const gulp = require('gulp'),
    pump = require('pump'),
    runSequence = require('run-sequence');

const configuration = {
    index: {
        path: 'index.html'
    },
    app: {
        name: 'app',
        all: 'app/**/*.js'
    },
    sass: {
        all: 'app/**/*.scss'
    },
    html: {
        all: 'app/**/*.html'
    },
    assets: {
        name: 'assets',
        all: 'assets/**/*',
        css: 'assets/css/'
    },
    dist: {
        name: 'dist',
        path: 'dist/'
    },
    dev: {
        name: 'dev',
        path: 'dev/'
    }
};

require('./gulp/build.js')(configuration);
require('./gulp/copy.js')(configuration);
require('./gulp/inject.js')(configuration);
require('./gulp/utils.js')(configuration);

gulp.task('build', (callback) => {
    runSequence('clean', 'build:app', 'build:sass', 'copy:assets', 'copy:html', 'useref');
});

gulp.task('build:watch', () => {
    gulp.watch([configuration.app.all, configuration.sass.all, configuration.assets.all], () => {
        runSequence('clean', 'build:app', 'build:sass', 'copy:assets', 'copy:html', 'useref');
    });
});
