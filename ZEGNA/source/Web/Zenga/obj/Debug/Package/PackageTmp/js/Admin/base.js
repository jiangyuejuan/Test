(function($) {
    "use strict";

    $.fn.tree = function() {

        return this.each(function() {
            var btn = $(this).children("a").first();
            var menu = $(this).children(".treeview-menu").first();
            var isActive = $(this).hasClass('active');

            //initialize already active menus
            if (isActive) {
                menu.show();
                btn.children(".fa-angle-left").first().removeClass("fa-angle-left").addClass("fa-angle-down");
            }
            //Slide open or close the menu on link click
            btn.click(function(e) {
                e.preventDefault();
                if (isActive) {
                    //Slide up to close menu
                    menu.slideUp();
                    isActive = false;
                    btn.children(".fa-angle-down").first().removeClass("fa-angle-down").addClass("fa-angle-left");
                    btn.parent("li").removeClass("active");
                } else {
                    //Slide down to open menu
                    menu.slideDown();
                    isActive = true;
                    btn.children(".fa-angle-left").first().removeClass("fa-angle-left").addClass("fa-angle-down");
                    btn.parent("li").addClass("active");
                }
            });

            /* Add margins to submenu elements to give it a tree look */
            menu.find("li > a").each(function() {
                var pad = parseInt($(this).css("margin-left")) + 10;

                $(this).css({"margin-left": pad + "px"});
            });

        });

    };


}(jQuery));

$(function(){
    $("[data-toggle='offcanvas']").click(function(e) {
        e.preventDefault();

        //If window is small enough, enable sidebar push menu
        if ($(window).width() <= 992) {
            $('.row-offcanvas').toggleClass('active');
            $('.left-side').removeClass("collapse-left");
            $(".right-side").removeClass("strech");
            $('.row-offcanvas').toggleClass("relative");
        } else {
            //Else, enable content streching
            $('.left-side').toggleClass("collapse-left");
            $(".right-side").toggleClass("strech");
        }
    });


    // $('.sidebar-menu a').click(function(){
    //     console.log($(this).attr('href'));
    //     return false;
    // });

});

//窗口大小改变处理
function _fix() {
    //Get window height and the wrapper height
    var height = $(window).height() - $("body > .header").height();
    $(".wrapper").css("min-height", height + "px");
    var content = $(".wrapper").height();
    //If the wrapper height is greater than the window
    if (content > height)
        //then set sidebar height to the wrapper
        $(".left-side, html, body").css("min-height", content + "px");
    else {
        //Otherwise, set the sidebar to the height of the window
        $(".left-side, html, body").css("min-height", height + "px");
    }
}
//Fire upon load
_fix();
//Fire when wrapper is resized
$(window).resize(function() {

    _fix();
    //fix_sidebar();
});


//iCheck
/*! iCheck v1.0.1 by Damir Sultanov, http://git.io/arlzeA, MIT Licensed */
(function(h) {
    function F(a, b, d) {
        var c = a[0], e = /er/.test(d) ? m : /bl/.test(d) ? s : l, f = d == H ? {checked: c[l], disabled: c[s], indeterminate: "true" == a.attr(m) || "false" == a.attr(w)} : c[e];
        if (/^(ch|di|in)/.test(d) && !f)
            D(a, e);
        else if (/^(un|en|de)/.test(d) && f)
            t(a, e);
        else if (d == H)
            for (e in f)
                f[e] ? D(a, e, !0) : t(a, e, !0);
        else if (!b || "toggle" == d) {
            if (!b)
                a[p]("ifClicked");
            f ? c[n] !== u && t(a, e) : D(a, e)
        }
    }
    function D(a, b, d) {
        var c = a[0], e = a.parent(), f = b == l, A = b == m, B = b == s, K = A ? w : f ? E : "enabled", p = k(a, K + x(c[n])), N = k(a, b + x(c[n]));
        if (!0 !== c[b]) {
            if (!d &&
                    b == l && c[n] == u && c.name) {
                var C = a.closest("form"), r = 'input[name="' + c.name + '"]', r = C.length ? C.find(r) : h(r);
                r.each(function() {
                    this !== c && h(this).data(q) && t(h(this), b)
                })
            }
            A ? (c[b] = !0, c[l] && t(a, l, "force")) : (d || (c[b] = !0), f && c[m] && t(a, m, !1));
            L(a, f, b, d)
        }
        c[s] && k(a, y, !0) && e.find("." + I).css(y, "default");
        e[v](N || k(a, b) || "");
        B ? e.attr("aria-disabled", "true") : e.attr("aria-checked", A ? "mixed" : "true");
        e[z](p || k(a, K) || "")
    }
    function t(a, b, d) {
        var c = a[0], e = a.parent(), f = b == l, h = b == m, q = b == s, p = h ? w : f ? E : "enabled", t = k(a, p + x(c[n])),
                u = k(a, b + x(c[n]));
        if (!1 !== c[b]) {
            if (h || !d || "force" == d)
                c[b] = !1;
            L(a, f, p, d)
        }
        !c[s] && k(a, y, !0) && e.find("." + I).css(y, "pointer");
        e[z](u || k(a, b) || "");
        q ? e.attr("aria-disabled", "false") : e.attr("aria-checked", "false");
        e[v](t || k(a, p) || "")
    }
    function M(a, b) {
        if (a.data(q)) {
            a.parent().html(a.attr("style", a.data(q).s || ""));
            if (b)
                a[p](b);
            a.off(".i").unwrap();
            h(G + '[for="' + a[0].id + '"]').add(a.closest(G)).off(".i")
        }
    }
    function k(a, b, d) {
        if (a.data(q))
            return a.data(q).o[b + (d ? "" : "Class")]
    }
    function x(a) {
        return a.charAt(0).toUpperCase() +
                a.slice(1)
    }
    function L(a, b, d, c) {
        if (!c) {
            if (b)
                a[p]("ifToggled");
            a[p]("ifChanged")[p]("if" + x(d))
        }
    }
    var q = "iCheck", I = q + "-helper", u = "radio", l = "checked", E = "un" + l, s = "disabled", w = "determinate", m = "in" + w, H = "update", n = "type", v = "addClass", z = "removeClass", p = "trigger", G = "label", y = "cursor", J = /ipad|iphone|ipod|android|blackberry|windows phone|opera mini|silk/i.test(navigator.userAgent);
    h.fn[q] = function(a, b) {
        var d = 'input[type="checkbox"], input[type="' + u + '"]', c = h(), e = function(a) {
            a.each(function() {
                var a = h(this);
                c = a.is(d) ?
                        c.add(a) : c.add(a.find(d))
            })
        };
        if (/^(check|uncheck|toggle|indeterminate|determinate|disable|enable|update|destroy)$/i.test(a))
            return a = a.toLowerCase(), e(this), c.each(function() {
                var c = h(this);
                "destroy" == a ? M(c, "ifDestroyed") : F(c, !0, a);
                h.isFunction(b) && b()
            });
        if ("object" != typeof a && a)
            return this;
        var f = h.extend({checkedClass: l, disabledClass: s, indeterminateClass: m, labelHover: !0, aria: !1}, a), k = f.handle, B = f.hoverClass || "hover", x = f.focusClass || "focus", w = f.activeClass || "active", y = !!f.labelHover, C = f.labelHoverClass ||
                "hover", r = ("" + f.increaseArea).replace("%", "") | 0;
        if ("checkbox" == k || k == u)
            d = 'input[type="' + k + '"]';
        -50 > r && (r = -50);
        e(this);
        return c.each(function() {
            var a = h(this);
            M(a);
            var c = this, b = c.id, e = -r + "%", d = 100 + 2 * r + "%", d = {position: "absolute", top: e, left: e, display: "block", width: d, height: d, margin: 0, padding: 0, background: "#fff", border: 0, opacity: 0}, e = J ? {position: "absolute", visibility: "hidden"} : r ? d : {position: "absolute", opacity: 0}, k = "checkbox" == c[n] ? f.checkboxClass || "icheckbox" : f.radioClass || "i" + u, m = h(G + '[for="' + b + '"]').add(a.closest(G)),
                    A = !!f.aria, E = q + "-" + Math.random().toString(36).replace("0.", ""), g = '<div class="' + k + '" ' + (A ? 'role="' + c[n] + '" ' : "");
            m.length && A && m.each(function() {
                g += 'aria-labelledby="';
                this.id ? g += this.id : (this.id = E, g += E);
                g += '"'
            });
            g = a.wrap(g + "/>")[p]("ifCreated").parent().append(f.insert);
            d = h('<ins class="' + I + '"/>').css(d).appendTo(g);
            a.data(q, {o: f, s: a.attr("style")}).css(e);
            f.inheritClass && g[v](c.className || "");
            f.inheritID && b && g.attr("id", q + "-" + b);
            "static" == g.css("position") && g.css("position", "relative");
            F(a, !0, H);
            if (m.length)
                m.on("click.i mouseover.i mouseout.i touchbegin.i touchend.i", function(b) {
                    var d = b[n], e = h(this);
                    if (!c[s]) {
                        if ("click" == d) {
                            if (h(b.target).is("a"))
                                return;
                            F(a, !1, !0)
                        } else
                            y && (/ut|nd/.test(d) ? (g[z](B), e[z](C)) : (g[v](B), e[v](C)));
                        if (J)
                            b.stopPropagation();
                        else
                            return!1
                    }
                });
            a.on("click.i focus.i blur.i keyup.i keydown.i keypress.i", function(b) {
                var d = b[n];
                b = b.keyCode;
                if ("click" == d)
                    return!1;
                if ("keydown" == d && 32 == b)
                    return c[n] == u && c[l] || (c[l] ? t(a, l) : D(a, l)), !1;
                if ("keyup" == d && c[n] == u)
                    !c[l] && D(a, l);
                else if (/us|ur/.test(d))
                    g["blur" ==
                            d ? z : v](x)
            });
            d.on("click mousedown mouseup mouseover mouseout touchbegin.i touchend.i", function(b) {
                var d = b[n], e = /wn|up/.test(d) ? w : B;
                if (!c[s]) {
                    if ("click" == d)
                        F(a, !1, !0);
                    else {
                        if (/wn|er|in/.test(d))
                            g[v](e);
                        else
                            g[z](e + " " + w);
                        if (m.length && y && e == B)
                            m[/ut|nd/.test(d) ? z : v](C)
                    }
                    if (J)
                        b.stopPropagation();
                    else
                        return!1
                }
            })
        })
    }
})(window.jQuery || window.Zepto);



/* Sidebar tree view */
$(".sidebar .treeview").tree();


//load页面
function Load_tpls(obj,toDom){
    this.obj = obj;
    this.toDom = toDom;
    this.main=function(){
        this.event();
    }
    this.event=function(){
        _this=this;
        this.obj.click(function(){  
            var url = $(this).attr('href');
            _this.addPage(url,_this.toDom);
            return false;
        }); 
    }
    this.loading_img=function(m){
        m==1?this.toDom.addClass('loading_img'):this.toDom.removeClass('loading_img');
    }
    this.addPage=function(url,toDom){
        if(url=='#'||url=='javascript:;') return false;
        _this.loading_img(1);
        toDom.load(url,function(){
            _this.loading_img(0);
        });
    }
    return this.main(obj,toDom);
}

//确认框
function jsConfirm(Obj) {
    if(!Obj){
        var Obj = {};
        Obj.title = Obj.content = Obj.conw = Obj.obj  = Obj.Param  = Obj.obj_text  = Obj.close_obj  = Obj.close_Param = Obj.close_text = false;
    }
    Tinfo = {
        title: Obj.title || "提示",
        content: Obj.content || "确定要删除吗！",
        //提示内容
        conw: Obj.conw || 300,
        //宽度
        obj: Obj.obj || false,
        //执行方法
        Param: Obj.Param || '',
        //执行方法参数
        obj_text: Obj.obj_text || '确定',
        //执行方法按钮内容
        close_obj: Obj.close_obj || false,
        //取消方法
        close_Param: Obj.close_Param || '',
        //取消方法参数
        close_text: Obj.close_text || '取消'
        //取消方法按钮内容
    };
    //var qr = '<div class="WJButton wj_blue tcQz">'+ Tinfo.obj_text +'</div>';
    //var qx = '<div class="WJButton wj_blue uniteC">'+ Tinfo.close_text +'</div>';
    //var con = '<div class="tccCon">' + '<div class="tccCon_t">'+ Tinfo.content +'</div><div class="tccCon_a">' + qr + qx + '</div></div>';

    //模态框
    var con = '<div class="modal fade" id="jsConfirm" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">'+
       '<div class="modal-dialog">'+
          '<div class="modal-content">'+
             '<div class="modal-header">'+
                '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>'+
                '<h4 class="modal-title" id="myModalLabel">'+
                   + Tinfo.title +
                '</h4>'+
             '</div>'+
             '<div class="modal-body">'+
                + Tinfo.content +
             '</div>'+
             '<div class="modal-footer">'+
                '<button type="button" class="btn btn-default" data-dismiss="modal">'+ Tinfo.close_text +'</button>'+
                '<button type="button" class="btn btn-primary">'+ Tinfo.obj_text +'</button>'+
             '</div>'+
          '</div>'+
    '</div>';

    var toDom = $('#jsConfirm');

    if(toDom.length>0){
        toDom.find('.modal-title').html(Tinfo.title);
        toDom.find('.modal-body').html(Tinfo.title);
        toDom.find('.modal-footer').html('<button type="button" class="btn btn-default" data-dismiss="modal">'+ Tinfo.close_text +'</button><button type="button" class="btn btn-primary">'+ Tinfo.obj_text +'</button>');
    }else{
        $('body').append(con);
    }

    setTimeout(function(){toDom.modal('show');},5500);

    //创建弹出层         
    // var wb = new jsbox({
    //     onlyid: "maptss",
    //     title: Tinfo.title,
    //     conw: Tinfo.conw,
    //     // FixedTop:170,
    //     content: con,
    //     range: true,
    //     mack: true
    // }).show();

    // //确定事件
    // $('.tcQz').die().live('click', function() {
    //     var isReturn = Tinfo.obj(Tinfo.Param);
    //     if(isReturn==undefined || isReturn==null){
    //       $('.jsbox_close').click();
    //     }
    // });
    // //取消事件
    // $('.uniteC').one('click', function() {
    //     if(Tinfo.close_obj) {
    //         Tinfo.close_obj(Tinfo.close_Param);
    //     }
    //     $('.jsbox_close').click();
    // });
    // //关闭按钮取消事件
    // $('.jsbox_close').one('mousedown', function() {
    //     if(Tinfo.close_obj) {
    //         Tinfo.close_obj(Tinfo.close_Param);
    //     }
    //     $('.jsbox_close').click();
    //     return false;
    // });

}


//ajaxSubmit
function ajaxSubmit(obj) {
    var url = $(obj).attr("action") || window.location.href;
    var callback_name = $(obj).attr("callback");
    var callback = null;
    eval("callback = " + callback_name + "");
    var data = {};
    $.map($('.edit_user').serializeArray(), function(item) {
        var name = data[item.name];
        var isArray = /\[\]$/;
        if(isArray.test(item.name)){
            if(!name){name=[]}
            name.push(item.value);
        }else{
            name = item.value;
        }
    });
    $.ajax({
        url: url,
        type: "POST",
        data: data,
        dataType: "JSON",
        success: function(ret) {
            if(ret.status == "200") {
                if(isNotEmpty(callback)) {
                    callback(ret);
                }
            } else if(ret.status == null) {
                alert("加载错误");
            }

        }
    });
}


/* ==========================================================
 * sco.confirm.js
 * http://github.com/terebentina/sco.js
 * ==========================================================
 * Copyright 2013 Dan Caragea.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ========================================================== */
 
/*jshint laxcomma:true, sub:true, browser:true, jquery:true, devel:true */
 
;(function($, undefined) {
    "use strict";
 
    var pluginName = 'scojs_confirm';
 
    function Confirm(options) {
        this.options = $.extend({}, $.fn[pluginName].defaults, options);
 
        var $modal = $(this.options.target);
        if (!$modal.length) {
            $modal = $('<div class="modal" id="' + this.options.target.substr(1) + '"><div class="modal-dialog"><div class="modal-content"><div class="modal-body inner"/><div class="modal-footer"><a class="btn btn-default" href="#" data-dismiss="modal">cancel</a> <a href="#" class="btn btn-danger" data-action="1">yes</a></div></div></div></div>').appendTo(this.options.appendTo).hide();
            if (typeof this.options.action == 'function') {
                var self = this;
                $modal.find('[data-action]').attr('href', '#').on('click.' + pluginName, function(e) {
                    e.preventDefault();
                    self.options.action.call(self);
                    self.close();
                });
            } else if (typeof this.options.action == 'string') {
                $modal.find('[data-action]').attr('href', this.options.action);
            }
        }
        this.scomodal = $.scojs_modal(this.options);
    }
 
    $.extend(Confirm.prototype, {
        show: function() {
            this.scomodal.show();
            return this;
        }
 
        ,close: function() {
            this.scomodal.close();
            return this;
        }
 
        ,destroy: function() {
            this.scomodal.destroy();
            return this;
        }
    });
 
 
    $.fn[pluginName] = function(options) {
        return this.each(function() {
            var obj;
            if (!(obj = $.data(this, pluginName))) {
                var $this = $(this)
                    ,data = $this.data()
                    ,title = $this.attr('title') || data.title
                    ,opts = $.extend({}, $.fn[pluginName].defaults, options, data)
                    ;
                if (!title) {
                    title = 'this';
                }
                opts.content = opts.content.replace(':title', title);
                if (!opts.action) {
                    opts.action = $this.attr('href');
                } else if (typeof window[opts.action] == 'function') {
                    opts.action = window[opts.action];
                }
                obj = new Confirm(opts);
                $.data(this, pluginName, obj);
            }
            obj.show();
        });
    };
 
    $[pluginName] = function(options) {
        return new Confirm(options);
    };
 
    $.fn[pluginName].defaults = {
        content: 'Are you sure you want to delete :title?'
        ,cssclass: 'confirm_modal'
        ,target: '#confirm_modal'   // this must be an id. This is a limitation for now, @todo should be fixed
        ,appendTo: 'body'   // where should the modal be appended to (default to document.body). Added for unit tests, not really needed in real life.
    };
 
    $(document).on('click.' + pluginName, '[data-trigger="confirm"]', function() {
        $(this)[pluginName]();
        return false;
    });
})(jQuery);





/* ==========================================================
 * sco.modal.js
 * http://github.com/terebentina/sco.js
 * ==========================================================
 * Copyright 2013 Dan Caragea.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ========================================================== */
 
/*jshint laxcomma:true, sub:true, browser:true, jquery:true, devel:true, eqeqeq:false */
/*global Spinner:true */
 
;(function($, undefined) {
    "use strict";
 
    var pluginName = 'scojs_modal';
 
    function Modal(options) {
        this.options = $.extend({}, $.fn[pluginName].defaults, options);
        this.$modal = $(this.options.target).attr('class', 'modal fade').hide();
        var self = this;
 
        function init() {
            if (self.options.title === '') {
                self.options.title = '&nbsp;';
            }
        };
 
        init();
    }
 
 
    $.extend(Modal.prototype, {
        show: function() {
            var self = this
                ,$backdrop;
 
            if (!this.options.nobackdrop) {
                $backdrop = $('.modal-backdrop');
            }
            if (!this.$modal.length) {
                this.$modal = $('<div class="modal fade" id="' + this.options.target.substr(1) + '"><div class="modal-dialog"><div class="modal-content"><div class="modal-header"><a class="close" href="#" data-dismiss="modal" aria-hidden="true">&times;</a><h3>&nbsp;</h3></div><div class="inner"/></div></div></div>').appendTo(this.options.appendTo).hide();
            }
 
            this.$modal.find('.modal-header h3').html(this.options.title);
 
            if (this.options.cssclass !== undefined) {
                this.$modal.attr('class', 'modal fade ' + this.options.cssclass);
            }
 
            if (this.options.width !== undefined) {
                this.$modal.width(this.options.width);
            }
 
            if (this.options.left !== undefined) {
                this.$modal.css({'left': this.options.left});
            }
 
            if (this.options.height !== undefined) {
                this.$modal.height(this.options.height);
            }
 
            if (this.options.top !== undefined) {
                this.$modal.css({'top': this.options.top});
            }
 
            if (this.options.keyboard) {
                this.escape();
            }
 
            if (!this.options.nobackdrop) {
                if (!$backdrop.length) {
                    $backdrop = $('<div class="modal-backdrop fade" />').appendTo(this.options.appendTo);
                }
                $backdrop[0].offsetWidth; // force reflow
                $backdrop.addClass('in');
            }
 
            this.$modal.off('close.' + pluginName).on('close.' + pluginName, function() {
                self.close.call(self);
            });
            if (this.options.remote !== undefined && this.options.remote != '' && this.options.remote !== '#') {
                var spinner;
                if (typeof Spinner == 'function') {
                    spinner = new Spinner({color: '#3d9bce'}).spin(this.$modal[0]);
                }
                this.$modal.find('.inner').load(this.options.remote, function() {
                    if (spinner) {
                        spinner.stop();
                    }
                    if (self.options.cache) {
                        self.options.content = $(this).html();
                        delete self.options.remote;
                    }
                });
            } else {
                this.$modal.find('.inner').html(this.options.content);
            }
 
            this.$modal.show().addClass('in');
            return this;
        }
 
        ,close: function() {
            this.$modal.hide().off('.' + pluginName).find('.inner').html('');
            if (this.options.cssclass !== undefined) {
                this.$modal.removeClass(this.options.cssclass);
            }
            $(document).off('keyup.' + pluginName);
            $('.modal-backdrop').remove();
            if (typeof this.options.onClose === 'function') {
                this.options.onClose.call(this, this.options);
            }
            return this;
        }
 
        ,destroy: function() {
            this.$modal.remove();
            $(document).off('keyup.' + pluginName);
            $('.modal-backdrop').remove();
            this.$modal = null;
            return this;
        }
 
        ,escape: function() {
            var self = this;
            $(document).on('keyup.' + pluginName, function(e) {
                if (e.which == 27) {
                    self.close();
                }
            });
        }
    });
 
 
    $.fn[pluginName] = function(options) {
        return this.each(function() {
            var obj;
            if (!(obj = $.data(this, pluginName))) {
                var  $this = $(this)
                    ,data = $this.data()
                    ,opts = $.extend({}, options, data)
                    ;
                if ($this.attr('href') !== '' && $this.attr('href') != '#') {
                    opts.remote = $this.attr('href');
                }
                obj = new Modal(opts);
                $.data(this, pluginName, obj);
            }
            obj.show();
        });
    };
 
 
    $[pluginName] = function(options) {
        return new Modal(options);
    };
 
 
    $.fn[pluginName].defaults = {
        title: '&nbsp;'     // modal title
        ,target: '#modal'   // the modal id. MUST be an id for now.
        ,content: ''        // the static modal content (in case it's not loaded via ajax)
        ,appendTo: 'body'   // where should the modal be appended to (default to document.body). Added for unit tests, not really needed in real life.
        ,cache: false       // should we cache the output of the ajax calls so that next time they're shown from cache?
        ,keyboard: false
        ,nobackdrop: false
    };
 
 
    $(document).on('click.' + pluginName, '[data-trigger="modal"]', function() {
        $(this)[pluginName]();
        if ($(this).is('a')) {
            return false;
        }
    }).on('click.' + pluginName, '[data-dismiss="modal"]', function(e) {
        e.preventDefault();
        $(this).closest('.modal').trigger('close');
    });
})(jQuery);