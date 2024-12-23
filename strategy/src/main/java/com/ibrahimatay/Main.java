package com.ibrahimatay;

import java.util.ArrayList;
import java.util.List;

interface Plugin {
    void call();
}

class PluginManager {
    final List<Plugin> plugins;

    PluginManager(Plugin... plugins) {
        this.plugins = new ArrayList<>();
        this.plugins.addAll(List.of(plugins));
    }

    public void call() {
        for(Plugin plugin : plugins) {
            plugin.call();
        }
    }
}

class EnginePlugin implements Plugin {
    @Override
    public void call() {
        System.out.println("Engine Plugin Called");
    }
}

class DataManagementPlugin implements Plugin {
    @Override
    public void call() {
        System.out.println("Data Management Plugin Called");
    }
}

public class Main {
    public static void main(String[] args) {
        PluginManager pluginManager = new PluginManager(new DataManagementPlugin(), new EnginePlugin());
        pluginManager.call();
    }
}