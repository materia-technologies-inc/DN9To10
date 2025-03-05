/**
 * @license
 * Copyright 2024 Materia Technologies, Inc.
 */

import resolve from '@rollup/plugin-node-resolve';
import summary from 'rollup-plugin-summary';

export default {
    input: 'Website/Scripts/Website.js',
    output: {
        file: 'Website/wwwroot/generated-content/website.js',
        format: 'esm',
    },
    onwarn(warning) {
        if (warning.code !== 'THIS_IS_UNDEFINED') {
            console.error(`(!) ${warning.message}`);
        }
    },
    plugins: [
        resolve(),
        summary(),
    ],
};
