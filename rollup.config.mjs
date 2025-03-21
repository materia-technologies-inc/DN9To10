/**
 * @license
 * Copyright 2024 Materia Technologies, Inc.
 */

import resolve from '@rollup/plugin-node-resolve';
import summary from 'rollup-plugin-summary';

export default {
    input: ".destination/BlazorComponents.js",
    output: [
        {
            "file": "BlazorComponents/wwwroot/generated-content/blazor.components.js",
            "format": "esm",
            "sourcemap": false
        }
    ],
    onwarn(warning) {
        if (warning.code !== 'THIS_IS_UNDEFINED') {
            console.error(`(!) ${warning.message}`);
            throw new Error(warning.message);
        }
    },
    plugins: [
        resolve(),
        summary(),
    ],
};
